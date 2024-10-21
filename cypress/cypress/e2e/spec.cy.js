describe('Test local website', () => {
  it('passes', () => {
    cy.visit('index.html')
  })

  it("ensures the topbar links exist", () => {
    cy.visit("index.html")

    cy.get("#link1").should("not.be.null")
    cy.get("#link2").should("not.be.null")
    cy.get("#link3").should("not.be.null")
    cy.get("#link4").should("not.be.null")
    cy.get("#link5").should("not.be.null")
    cy.get("#link6").should("not.be.null")
  }) 

  it("ensures the site's title changes", () => {
    cy.visit("index.html")

    let textarea = cy.get("#change-title-box").should("not.be.null")
    let submitButton = cy.get("#btn").should("not.be.null")

    const newTitle = "A new site title"

    textarea.type(newTitle)
    submitButton.click()

    let titles = cy.get('[name="site-title-area"]').should("have.length", 2)
    titles.each((el) => {
      cy.wrap(el).should("have.text", newTitle)
    })
  })
})