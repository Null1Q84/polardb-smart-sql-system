#!/bin/bash

# 本地部署脚本
echo "🚀 手机端指挥Web开发本地部署"
echo "============================="

# 启动本地服务器
echo "启动本地服务器..."
python3 -m http.server 8000 &
SERVER_PID=$!

# 获取本机IP
LOCAL_IP=$(hostname -I | awk '{print $1}')
echo ""
echo "✅ 服务器已启动："
echo "PID: $SERVER_PID"
echo "端口: 8000"
echo "IP地址: $LOCAL_IP"
echo ""

# 生成访问信息
echo "📱 手机访问方式："
echo "1. 确保手机和电脑在同一局域网"
echo "2. 手机浏览器输入：http://$LOCAL_IP:8000"
echo "3. 或使用二维码页面：http://$LOCAL_IP:8000/QR-Code.html"
echo ""

# 生成二维码链接
QR_URL="http://$LOCAL_IP:8000"
QR_API_URL="https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=$QR_URL"
echo "二维码生成链接："
echo "$QR_API_URL"
echo ""

# 快速部署流程
echo "🔧 快速部署流程："
echo "1. 你在手机元宝端发送指令"
echo "2. 我修改代码文件"
echo "3. 手机刷新页面查看更新"
echo ""

# 查看服务器状态
echo "🔍 服务器状态："
netstat -tlnp | grep 8000 || echo "端口8000正在监听"
echo ""

echo "按 Ctrl+C 停止服务器"
echo "============================="

wait $SERVER_PID