const { spawnSync } = require('child_process')
spawnSync('npm', ['install'], { stdio: 'inherit', cwd: 'client', shell: true })
spawnSync('npm', ['run', 'build'], { stdio: 'inherit', cwd: 'client', shell: true })