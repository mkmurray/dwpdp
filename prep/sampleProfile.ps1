$env:TERM = 'cygwin'
$env:LESS = 'FRSX'

function prompt {
  $symbolicref = git symbolic-ref HEAD
  $isGetRepository = $symbolicref -ne $NULL

  $type = "PS "
  $branch = ""
  $color = "green"

  if ($isGetRepository) {
    $type = "GIT "
    $branch = $symbolicref.substring($symbolicref.LastIndexOf("/") + 1)
    $branch = " (" + $branch + ")"
    $color = "yellow"
  }

  Write-Host ($type + $(get-location) + $branch) -nonewline -foregroundcolor $color
  return " "
}
