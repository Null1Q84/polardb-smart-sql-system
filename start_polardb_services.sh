#!/bin/bash
# 启动PolarDB专用服务脚本

echo "=== 启动PolarDB DB-GPT + SQLFlow智能SQL系统 ==="

# 检查端口占用情况
echo "检查端口占用..."
for port in 8200 8201 8202; do
    if netstat -tlnp | grep ":$port" > /dev/null; then
        echo "端口 $port 已被占用"
    else
        echo "端口 $port 可用"
    fi
done

# 启动PolarDB DB-GPT服务
echo "启动PolarDB DB-GPT服务..."
cd /root/.openclaw/workspace
source sqlflow_env/bin/activate
python polar_db_gpt_service.py &
DB_GPT_PID=$!
echo "PolarDB DB-GPT服务PID: $DB_GPT_PID"

# 等待几秒让服务启动
sleep 2

# 启动PolarDB SQLFlow服务
echo "启动PolarDB SQLFlow服务..."
python polar_db_sqlflow_service.py &
SQLFLOW_PID=$!
echo "PolarDB SQLFlow服务PID: $SQLFLOW_PID"

# 等待几秒让服务启动
sleep 2

# 启动PolarDB网关服务
echo "启动PolarDB网关服务..."
python polar_db_gateway_service.py &
GATEWAY_PID=$!
echo "PolarDB网关服务PID: $GATEWAY_PID"

# 等待几秒让服务启动
sleep 3

# 检查服务状态
echo "检查服务状态..."
curl -s http://localhost:8201/health > /dev/null && echo "PolarDB DB-GPT服务状态: OK" || echo "PolarDB DB-GPT服务状态: 失败"
curl -s http://localhost:8202/health > /dev/null && echo "PolarDB SQLFlow服务状态: OK" || echo "PolarDB SQLFlow服务状态: 失败"
curl -s http://localhost:8200/polardb-gateway/health > /dev/null && echo "PolarDB网关服务状态: OK" || echo "PolarDB网关服务状态: 失败"

echo ""
echo "服务地址:"
echo "  PolarDB DB-GPT API: http://localhost:8201"
echo "  PolarDB SQLFlow API: http://localhost:8202"
echo "  PolarDB网关API: http://localhost:8200"
echo ""
echo "API端点:"
echo "  POST /polardb-dbgpt/generate - 生成PolarDB SQL"
echo "  POST /polardb-dbgpt/explain - 解释PolarDB SQL"
echo "  POST /polardb-sqlflow/analyze - 分析PolarDB SQL"
echo "  POST /polardb-sqlflow/optimize - 优化PolarDB SQL"
echo "  POST /polardb-gateway/generate - 完整流程生成PolarDB SQL"
echo "  GET /polardb-gateway/history - 获取历史记录"
echo "  GET /polardb-gateway/test - 测试系统"
echo ""
echo "测试PolarDB系统:"
echo "  curl -X POST http://localhost:8200/polardb-gateway/generate -H 'Content-Type: application/json' -d '{\"query\": \"查询所有用户\"}'"
echo ""
echo "停止服务:"
echo "  kill $DB_GPT_PID $SQLFLOW_PID $GATEWAY_PID"
echo ""
echo "=== PolarDB系统启动完成 ==="

# 保持脚本运行
read -p "按回车键停止服务..." 
echo "停止服务..."
kill $DB_GPT_PID $SQLFLOW_PID $GATEWAY_PID