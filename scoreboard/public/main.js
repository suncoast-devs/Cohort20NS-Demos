function main() {
  // Assign an event to the input fields to
  // automatically change the team's name
  // as the user types.

  // const inputOne = document.querySelector('.team-one input')
  // const teamOneHeading = document.querySelector('.team-one h2')
  // inputOne.addEventListener('input', () => {
  //   teamOneHeading.textContent = inputOne.value
  // })

  // const inputTwo = document.querySelector('.team-two input')
  // const teamTwoHeading = document.querySelector('.team-two h2')
  // inputTwo.addEventListener('input', () => {
  //   teamTwoHeading.textContent = inputTwo.value
  // })
  
  const sections = document.querySelectorAll('section')
  sections.forEach((section) => {
    let score = 0

    const input = section.querySelector('input')
    const teamHeading = section.querySelector('h2')
    const scoreHeading = section.querySelector('h3')
    const plusButton = section.querySelector('.add')
    const subtractButton = section.querySelector('.subtract')
    
    input.addEventListener('input', () => {
      teamHeading.textContent = input.value
    })

    plusButton.addEventListener('click', () => {
      scoreHeading.textContent = ++score
    })

    subtractButton.addEventListener('click', () => {
      scoreHeading.textContent = --score
    })
  })
}

document.addEventListener('DOMContentLoaded', main)
