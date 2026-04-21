#!/bin/bash
# Setup script for GitHub deployment

echo "🚀 GitHub Deployment Setup"

# 需要输入的信息
echo "请提供以下信息："

# GitHub 用户名
echo -n "GitHub 用户名: "
read GITHUB_USERNAME

# GitHub 仓库名
echo -n "GitHub 仓库名 (例如: gh-pages-skill): "
read REPO_NAME

# GitHub Token (可选)
echo -n "GitHub Token (或回车跳过): "
read GITHUB_TOKEN

# 设置 Git 配置
echo "设置 Git 配置..."
git config user.name "$GITHUB_USERNAME"
git config user.email "$GITHUB_USERNAME@users.noreply.github.com"

# 设置远程仓库
git remote add origin https://github.com/$GITHUB_USERNAME/$REPO_NAME.git

echo "✅ Git 配置完成"
echo "📦 仓库 URL: https://github.com/$GITHUB_USERNAME/$REPO_NAME"

# 如果有 Token，尝试推送
if [ -n "$GITHUB_TOKEN" ]; then
    echo "尝试推送到 GitHub..."
    # 使用 Token 推送
    export GITHUB_TOKEN="$GITHUB_TOKEN"
    export GITHUB_REPO="$GITHUB_USERNAME/$REPO_NAME"
    ./deploy.sh
else
    echo "手动推送步骤："
    echo "1. 创建仓库: https://github.com/new"
    echo "2. 仓库名: $REPO_NAME"
    echo "3. 不要初始化文件（空仓库）"
    echo "4. 然后运行: git push -u origin main"
fi