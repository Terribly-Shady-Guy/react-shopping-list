import React, { useState } from 'react';

function NewItemForm() {
    const [itemName, setItemName] = useState("");

    const handleInputChange = (e) => {
        setItemName(e.target.value);
    }

    const submitName = async () => {
        const reqBody = {
            itemName: itemName
        };

        await fetch("https://localhost:7146/api/shoppinglistitem", {
            method: 'POST',
            headers: { 'content-type': "application/json" },
            body: JSON.stringify(reqBody)
        });

        setItemName("");
    }

  return (
      <form>
          <input type="text" name="itemName" placeholder="Enter item name" onChange={handleInputChange} />
          <button onClick={ submitName }>Add</button>
      </form>
  );
}

export default NewItemForm;