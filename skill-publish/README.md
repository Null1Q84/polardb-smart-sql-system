# gh-pages-ai-integration Skill

A comprehensive skill for deploying AI-powered web applications, games, and static sites to GitHub Pages.

## Features

- **GitHub Pages Automation**: Complete deployment workflows
- **AI Integration**: Patterns for OpenAI, DeepSeek, and other AI APIs
- **Mobile Optimization**: QR code generation and touch-friendly design
- **Game Deployment**: WebGL/Canvas game optimization for GitHub Pages
- **GitHub Actions**: Automated CI/CD pipelines
- **Mobile-First Design**: Responsive layouts and touch event handling

## Installation

```bash
# Install using OpenClaw
openclaw skill install gh-pages-ai-integration

# Or install directly from GitHub
openclaw skill install https://github.com/yourusername/gh-pages-skill/raw/main/gh-pages-ai-integration.skill
```

## Quick Start

1. Clone the skill:
```bash
cp ~/.openclaw/workspace/skills/gh-pages-ai-integration.skill .
```

2. Use the skill in your projects:
```bash
# Initialize your project
git init
git add .
git commit -m "Initial commit"
```

3. Set up GitHub Pages:
```bash
# Enable Pages in GitHub repository settings
```

## Included Components

### Scripts
- `upload_to_github.py`: GitHub API upload automation
- `serve.sh`: Local development server

### References
- `ai_web_apps.md`: AI integration patterns
- `game_deployment.md`: Game optimization strategies
- `static_sites.md`: Static site deployment
- `api_integration.md`: API integration best practices

### Templates
- GitHub Actions workflow template
- Basic HTML/CSS/JS templates
- QR code template for mobile access

## Examples

### AI Chat Application
```html
<!-- index.html -->
<!DOCTYPE html>
<html>
<head>
    <title>AI Chat App</title>
</head>
<body>
    <div id="chat-container"></div>
</body>
</html>
```

### Web Game Deployment
```javascript
// Game with mobile controls
canvas.addEventListener('touchstart', handleTouch);
```

## License

MIT License - Free to use and modify

## Contributing

Feel free to submit issues and pull requests!