#!/usr/bin/env python3
"""
GitHub API Upload Script for Skill Publishing
Automatically upload skill files to GitHub repository and enable GitHub Pages deployment.
"""

import base64
import json
import os
import requests

def upload_file(file_path, repo_path, github_token, repo):
    """通过 GitHub API 上传单个文件"""
    try:
        # 读取文件内容并编码
        with open(file_path, 'rb') as f:
            content = f.read()
        content_base64 = base64.b64encode(content).decode('utf-8')
        
        # 构造 API 请求
        url = f"https://api.github.com/repos/{repo}/contents/{repo_path}"
        headers = {
            "Authorization": f"token {github_token}",
            "Accept": "application/vnd.github.v3+json"
        }
        
        data = {
            "message": f"Upload {repo_path}",
            "content": content_base64
        }
        
        response = requests.put(url, headers=headers, json=data)
        
        if response.status_code in [200, 201]:
            print(f"✅ {repo_path} uploaded successfully")
            return True
        else:
            print(f"❌ {repo_path} upload failed: {response.status_code} {response.text}")
            return False
    
    except Exception as e:
        print(f"❌ Error uploading {repo_path}: {str(e)}")
        return False

def enable_github_pages(github_token, repo):
    """启用 GitHub Pages"""
    try:
        pages_url = f"https://api.github.com/repos/{repo}/pages"
        headers = {
            "Authorization": f"token {github_token}",
            "Accept": "application/vnd.github.v3+json"
        }
        data = {
            "source": {
                "branch": "main",
                "path": "/"
            }
        }
        response = requests.post(pages_url, headers=headers, json=data)
        if response.status_code in [200, 201]:
            print("✅ GitHub Pages enabled")
            return True
        else:
            print(f"⚠️ GitHub Pages may need manual setup: {response.status_code}")
            return False
    except Exception as e:
        print(f"⚠️ GitHub Pages setup error: {str(e)}")
        return False

def deploy_skill_to_github(github_token, repo):
    """部署 skill 项目到 GitHub"""
    
    # 要上传的文件列表
    files_to_upload = [
        ("gh-pages-ai-integration.skill", "gh-pages-ai-integration.skill"),
        ("index.html", "index.html"),
        ("README.md", "README.md"),
    ]
    
    uploaded_count = 0
    project_dir = "./"
    
    for local_file, repo_path in files_to_upload:
        file_path = os.path.join(project_dir, local_file)
        if os.path.exists(file_path):
            if upload_file(file_path, repo_path, github_token, repo):
                uploaded_count += 1
    
    print(f"📊 Upload summary: {uploaded_count} files uploaded")
    
    # 启用 GitHub Pages
    if uploaded_count > 0:
        enable_github_pages(github_token, repo)
    
    print(f"\n🎉 Repository URL: https://github.com/{repo}")
    print(f"🌐 GitHub Pages URL: https://{repo.split('/')[0]}.github.io/{repo.split('/')[1]}")
    
    return uploaded_count

if __name__ == "__main__":
    # 配置 GitHub 信息
    GITHUB_TOKEN = os.environ.get("GITHUB_TOKEN")  # 从环境变量获取
    REPO = os.environ.get("GITHUB_REPO")  # 格式：username/repo-name
    
    if not GITHUB_TOKEN:
        print("⚠️ Please set GITHUB_TOKEN environment variable")
        print("Example: export GITHUB_TOKEN=your_token")
        exit(1)
    
    if not REPO:
        print("⚠️ Please set GITHUB_REPO environment variable")
        print("Example: export GITHUB_REPO=yourusername/gh-pages-skill")
        exit(1)
    
    # 部署 skill
    deploy_skill_to_github(GITHUB_TOKEN, REPO)