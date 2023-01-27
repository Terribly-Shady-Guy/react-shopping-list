import React, { useState } from 'react';
import "./App.css";

function ShoppingListItem({ props }) {
    const { itemId, itemName, isPickedUp } = props;

    const [pickedUpState, setPickedUpState] = useState(isPickedUp);

    const changePickedUpStatus = async () => {
        const reqBody = { id: itemId };

        const response = await fetch("https://localhost:7146/api/shoppinglistitem", {
            method: "PUT",
            headers: { 'content-type': "application/json" },
            body: JSON.stringify(reqBody)
        });

        if (response.status === 204) {
            setPickedUpState(!pickedUpState);
        }
    };

    let pickedUpClass = pickedUpState ? "picked-up" : "not-picked-up";

    return (
        <>
            <button type="button" className={pickedUpClass + " item"} onClick={changePickedUpStatus}>{itemName}</button>
        </>
    );
}

export default ShoppingListItem;