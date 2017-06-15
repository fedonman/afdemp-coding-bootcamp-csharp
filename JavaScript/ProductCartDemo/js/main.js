class Product {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }
}

class CartItem {
    constructor(product, quantity = 1) {
        this.product = product;
        this.quantity = quantity;
    }
}

window.onload = _ => {
    /* normally fetch this from server */
    let products = [
        new Product('Product 1', 4.5),
        new Product('Product 2', 3),
        new Product('Product 3', 5),
        new Product('Product 4', 6)
    ];

    let cart = [];

    let productsDiv = document.getElementById('products');
    let cartDiv = document.getElementById('cart');


    let productsHTML = '';
    products.forEach(x => {
        productsHTML += `<li>${x.name} - ${x.price} <button id='${x.name}'>Add</button></li>`;
    });
    productsDiv.innerHTML = productsHTML;

    let renderCart = _ => {
        cartDiv.innerHTML = '';
        cart.forEach(x => {
            cartDiv.innerHTML += `<li>${x.product.name} - ${x.quantity}</li>`;
        });
    }

    let addButtons = productsDiv.getElementsByTagName('button');
    Array.from(addButtons).map(x => {
        let id = x.getAttribute('id');
        x.onclick = _ => {
            let index = cart.findIndex(x => x.product.name === id);
            if (index === -1) {
                let p = products.find(x => x.name === id);
                cart.push(new CartItem(p, 1));
            }
            else {
                cart[index].quantity += 1;
            }
            renderCart();
        }
    });
}