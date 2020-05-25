// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var allUpQuantityButtonsPantry = document.querySelectorAll(".upQuantityButtonPantry")
allUpQuantityButtonsPantry.forEach(upQuantityButton => {
    upQuantityButton.addEventListener("click", async  event => {
        event.preventDefault();
        var itemId = event.target.value;
        var updatedQuantity = await fetch(`/Pantry/QuantityUp/${itemId}`, {
        method: "Post"
         }).then(res => res.json());

    var newQuantity = document.getElementById(`pantryItemQuantity--${itemId}`)
        newQuantity.innerHTML = `${updatedQuantity.quantity} ${updatedQuantity.quantityUnit.name}`;
        if (updatedQuantity.quantity !== 1 && updatedQuantity.quantityUnitId !== 8) {
            newQuantity.innerHTML += "s";
        }
    })
})

var allDownQuantityButtonsPantry = document.querySelectorAll(".downQuantityButtonPantry")
allDownQuantityButtonsPantry.forEach(downQuantityButton => {
    downQuantityButton.addEventListener("click", async  event => {
        event.preventDefault();
        var itemId = event.target.value;
        var updatedQuantity = await fetch(`/Pantry/QuantityDown/${itemId}`, {
            method: "Post"
        }).then(res => res.json());

        if (updatedQuantity.quantity == 0) {
            var tableRow = document.getElementById(`pantryTableRow--${itemId}`)
            tableRow.remove();
        } else {
        var newQuantity = document.getElementById(`pantryItemQuantity--${itemId}`)
            newQuantity.innerHTML = `${updatedQuantity.quantity} ${updatedQuantity.quantityUnit.name}`;
            if (updatedQuantity.quantity !== 1 && updatedQuantity.quantityUnitId !== 8) {
                newQuantity.innerHTML += "s";
            }
        }
    })
})

var allUpQuantityButtonsGrocery = document.querySelectorAll(".upQuantityButtonGrocery")
allUpQuantityButtonsGrocery.forEach(upQuantityButton => {
    upQuantityButton.addEventListener("click", async  event => {
        event.preventDefault();
        var itemId = event.target.value;
        var updatedQuantity = await fetch(`/GroceryList/QuantityUp/${itemId}`, {
            method: "Post"
        }).then(res => res.json());

        var newQuantity = document.getElementById(`groceryItemQuantity--${itemId}`)
        newQuantity.innerHTML = `${updatedQuantity.quantity} ${updatedQuantity.food.quantityUnit.name}`;
        if (updatedQuantity.quantity !== 1 && updatedQuantity.food.quantityUnitId !== 8) {
            newQuantity.innerHTML += "s";
        }
    })
})

var allDownQuantityButtonsGrocery = document.querySelectorAll(".downQuantityButtonGrocery")
allDownQuantityButtonsGrocery.forEach(downQuantityButton => {
    downQuantityButton.addEventListener("click", async  event => {
        event.preventDefault();
        var itemId = event.target.value;
        var updatedQuantity = await fetch(`/GroceryList/QuantityDown/${itemId}`, {
            method: "Post"
        }).then(res => res.json());

        if (updatedQuantity.quantity == 0) {
            var tableRow = document.getElementById(`groceryTableRow--${itemId}`)
            tableRow.remove();
        } else {
            var newQuantity = document.getElementById(`groceryItemQuantity--${itemId}`)
            newQuantity.innerHTML = `${updatedQuantity.quantity} ${updatedQuantity.food.quantityUnit.name}`;
            if (updatedQuantity.quantity !== 1 && updatedQuantity.food.quantityUnitId !== 8) {
                newQuantity.innerHTML += "s";
            }
        }
    })
})
