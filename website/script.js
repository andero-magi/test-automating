
function changeTitles() {
  let container = document.getElementById("change-title-box")

  if (container == null) {
    return
  }

  let value = container.value
  if (isNullOrEmpty(value)) {
    value = "Site Title"
  }

  let elements = document.getElementsByName("site-title-area")
  elements.forEach(el => {
    el.textContent = value
  })
}

function isNullOrEmpty(str) {
  if (str == null) {
    return true
  }

  str = str.replaceAll(" ", "")

  if (str.length < 1 || str == "") {
    return true
  }

  return false
}