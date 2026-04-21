# 📱 手机端指挥Web开发部署指南

## 快速部署步骤

### 方案一：本地部署（无需GitHub）
1. **启动本地服务器**
   ```bash
   python3 -m http.server 8000
   ```
2. **手机访问**
   - 手机浏览器访问：http://电脑IP:8000
   - 二维码：http://电脑IP:8000/QR-Code.html

### 方案二：GitHub Pages（推荐）
1. **创建GitHub仓库**
   - 登录 GitHub
   - 创建新仓库：mobile-web-demo
   - 设置为公开仓库

2. **推送代码**
   ```bash
   git remote add origin https://github.com/[你的用户名]/mobile-web-demo.git
   git push -u origin main
   ```

3. **启用GitHub Pages**
   - 仓库设置 → Pages → 选择 main branch
   - 保存设置

4. **访问链接**
   - https://[你的用户名].github.io/mobile-web-demo/
   - 部署完成后自动生效

## 手机端指挥流程

### 1. 发送开发指令
在手机元宝端发送指令，例如：
```
"修改主页背景颜色"
```

### 2. AI执行
- 我修改对应代码文件
- 提交变更到GitHub

### 3. 查看效果
- 手机刷新 GitHub Pages 页面
- 实时看到更新效果

## GitHub Actions 部署配置

我已经创建了 `.github/workflows/deploy.yml`，包含：
- 自动部署到 GitHub Pages
- QR Code 生成
- 部署信息通知

## 准备就绪的文件

项目已包含：
- index.html（主页面）
- style.css（样式）
- script.js（交互功能）
- QR-Code.html（二维码展示）
- serve.sh（本地服务器脚本）
- MOBILE-DEMO.md（演示指南）

## 手机访问QR Code

![QR Code](https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=https://[你的用户名].github.io/mobile-web-demo/)

## 立即开始

选择方案一进行快速测试，或按照方案二配置 GitHub 进行线上部署。

**手机端指令示例：**
- "修改计数器按钮的背景颜色"
- "添加一个导航菜单"
- "优化页面响应式设计"
- "增加一个用户反馈表单"