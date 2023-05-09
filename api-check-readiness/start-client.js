const { spawn } = require('child_process')
spawn('yarn', ['start'], {
  stdio: 'inherit',
  cwd: 'client',
  shell: true
})