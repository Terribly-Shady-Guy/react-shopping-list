import React, { useState } from 'react';
import "./App.css";

function ShoppingListItem({ props }) {
    const { itemId, itemName, isPickedUp } = props;

    const [pickedUpState, setPickedUpState] = useState(isPickedUp);

    const changePickedUpStatus = () => {
        const reqBody = { id: itemId };

        fetch("https://localhost:7146/api/shoppinglistitem", {
            method: "PUT",
            headers: { 'content-type': "application/json" },
            body: JSON.stringify(reqBody)
        });

        setPickedUpState(!pickedUpState);
    };

    return (
        <>
            <p className={pickedUpState ? "picked-up" : "not-picked-up"}>{itemName}</p>
            <button type="button" onClick={changePickedUpStatus}>Check Off</button>
        </>
    );
}

export default ShoppingListItem;