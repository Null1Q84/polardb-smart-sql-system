#!/bin/bash

# 启动本地服务器演示
echo "启动手机端指挥开发演示服务器..."
echo "======================"

# 检查 Python3
if command -v python3 &> /dev/null; then
    echo "使用 Python3 启动服务器"
    python3 -m http.server 8000 &
elif command -v node &> /dev/null; then
    echo "使用 Node.js 启动服务器"
    npx http-server &
elif command -v python &> /dev/null; then
    echo "使用 Python 启动服务器"
    python -m http.server 8000 &
else
    echo "请安装 Python3 或 Node.js"
    exit 1
fi

SERVER_PID=$!
echo "服务器 PID: $SERVER_PID"
echo ""

# 生成访问信息
echo "手机访问方法："
echo "1. 在同一局域网内连接"
echo "2. 在手机浏览器输入以下地址："

# 获取本机 IP
LOCAL_IP=$(hostname -I | awk '{print $1}')
echo "   - http://$LOCAL_IP:8000"
echo "   - http://localhost:8000 (如果你电脑和手机在同一设备)"
echo ""

echo "二维码生成信息："
QR_URL="http://$LOCAL_IP:8000"
echo "访问地址: $QR_URL"
echo ""
echo "可以使用 QR Code API 生成二维码："
echo "https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=$QR_URL"
echo ""

echo "部署流程："
echo "1. 你通过手机元宝发送修改指令"
echo "2. 我会修改代码文件"
echo "3. 服务器自动刷新显示新内容"
echo "4. 你在手机浏览器刷新页面查看更新"
echo ""

echo "按 Ctrl+C 停止服务器"
wait $SERVER_PID