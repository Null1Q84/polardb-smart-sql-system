# gh-pages-ai-integration Skill 发布指南

## 文件清单

已创建的文件：
1. `gh-pages-ai-integration.skill` - OpenClaw 技能文件
2. `index.html` - 展示页面
3. `README.md` - 说明文档  
4. `upload_to_github.py` - GitHub API 上传脚本
5. `deploy.sh` - 自动化部署脚本

## 自动部署方法（需要 GitHub Token）

```bash
# 1. 设置环境变量
export GITHUB_TOKEN=你的个人访问令牌
export GITHUB_REPO=你的用户名/gh-pages-skill

# 2. 运行部署脚本
cd ~/.openclaw/workspace/skill-publish
./deploy.sh
```

## 手动部署方法

### 第一步：创建 GitHub 仓库
1. 访问 https://github.com/new
2. 创建名为 `gh-pages-skill` 的仓库
3. 不要初始化任何文件（空仓库）

### 第二步：上传文件
可以通过以下方式上传：
1. **GitHub 网页上传**：
   - 进入仓库页面
   - 点击 "Add file" → "Upload files"
   - 上传所有创建的文件

2. **命令行上传**：
```bash
# 初始化 git
cd ~/.openclaw/workspace/skill-publish
git init
git add .
git commit -m "Add gh-pages-ai-integration skill"
git remote add origin https://github.com/你的用户名/gh-pages-skill.git
git push -u origin main
```

### 第三步：启用 GitHub Pages
1. 进入仓库 Settings → Pages
2. Source: Branch: `main` → Root
3. Save 配置
4. 等待部署完成（1-3分钟）

### 第四步：分享链接
- GitHub 仓库：https://github.com/你的用户名/gh-pages-skill
- GitHub Pages：https://你的用户名.github.io/gh-pages-skill/
- QR 码：https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=https://你的用户名.github.io/gh-pages-skill/

## 快速测试
```bash
# 本地测试
python3 -m http.server 8080
# 浏览器访问 http://localhost:8080
```

## 文件说明

### gh-pages-ai-integration.skill
完整的 OpenClaw 技能文件，包含：
- GitHub Pages 部署自动化
- AI API 集成模式
- 游戏部署优化
- QR 码生成
- GitHub Actions 模板
- 移动端优化

### upload_to_github.py
Python 脚本用于通过 GitHub API 自动上传文件到仓库。

### deploy.sh
Bash 脚本一键部署（需要 GitHub Token）。

### index.html
展示页面，包含 QR 码和技能介绍。

### README.md
详细的技能文档和使用说明。