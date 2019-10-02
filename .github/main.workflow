workflow "Main workflow" {
  on = "push"
  resolves = ["Build"]
}

action "Build" {
  uses = "Build"
}
