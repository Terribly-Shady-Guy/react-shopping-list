import React from 'react';
import { useEffect, useState } from 'react';
import NewItemForm from './NewItemForm';
import ShoppingListItem from './ShoppingListItem';

function App() {
    const [shoppingList, setShoppingList] = useState([]);

    useEffect(() => {
        const controller = new AbortController();

        fetch("https://localhost:7146/api/shoppinglistitem", {signal: controller.signal})
            .then((res) => res.json())
            .then((data) => setShoppingList(data))
            .catch((e) => console.log(e.message));

        return () => controller.abort();
    }, []);


  return (
      <div className="App">
          <NewItemForm />
          <h1>Shopping List</h1>
          {shoppingList.length === 0 ? <h1>Loading Data...</h1>
              :
              shoppingList.map((item) => <ShoppingListItem props={item} key={item.itemId} />)}
      </div>
  );
}

export default App;