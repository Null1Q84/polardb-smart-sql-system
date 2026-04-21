#!/bin/bash
# Deploy gh-pages-ai-integration skill to GitHub

echo "🚀 Deploying gh-pages-ai-integration skill to GitHub..."

# 检查 git 是否初始化
if [ ! -d .git ]; then
    echo "Initializing git repository..."
    git init
fi

# 检查是否设置了必要的环境变量
if [ -z "$GITHUB_TOKEN" ]; then
    echo "❌ GITHUB_TOKEN is not set. Please set it first:"
    echo "export GITHUB_TOKEN=your_github_token"
    exit 1
fi

if [ -z "$GITHUB_REPO" ]; then
    echo "❌ GITHUB_REPO is not set. Please set it first:"
    echo "export GITHUB_REPO=yourusername/gh-pages-skill"
    exit 1
fi

# 上传文件到 GitHub
python3 upload_to_github.py

# 初始化本地仓库
git add .
git commit -m "Add gh-pages-ai-integration skill"

# 设置远程仓库
git remote add origin https://github.com/${GITHUB_REPO}.git || git remote set-url origin https://github.com/${GITHUB_REPO}.git

# 推送到 GitHub
git push -u origin main

echo "✅ Deployment complete!"
echo "📱 QR Code: https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=https://${GITHUB_REPO%.*}.github.io/${GITHUB_REPO##*/}/"
echo "🌐 GitHub Pages URL: https://${GITHUB_REPO%.*}.github.io/${GITHUB_REPO##*/}/"
echo "📦 Repository URL: https://github.com/${GITHUB_REPO}"