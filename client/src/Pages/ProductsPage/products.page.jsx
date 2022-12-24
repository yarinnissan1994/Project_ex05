import React, { useEffect, useState } from "react";
import { getProducts } from "../../services/services";
import "./products.css";

export const ProductsPage = () => {
  const [productsData, setProductsData] = useState([]);
  const getProductsFromDB = async () => {
    let res = await getProducts();
    setProductsData(res);
    // console.log(res);
  };
  useEffect(() => {
    getProductsFromDB();
    //console.log(productsData);
  }, []);

  const [expanded, setExpanded] = useState(false);
  const [key, setKey] = useState(null);

  function handleClick(proKey) {
    setExpanded(!expanded);
    setKey(proKey);
  }

  return (
    <div className="my-tbl">
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Product Name</th>
            <th scope="col">Price</th>
            <th scope="col">Units In Stock</th>
          </tr>
        </thead>
        <tbody>
          {productsData &&
            productsData.map((product) => {
              return (
                <>
                  <tr onClick={() => handleClick(product.ProductID)}>
                    <th scope="row">{product.ProductID}</th>
                    <td>{product.ProductName}</td>
                    <td>{product.UnitPrice}$</td>
                    <td>{product.UnitsInStock}</td>
                  </tr>
                  {expanded && product.ProductID === key ? (
                    <tr className="expanded">
                      <td colSpan={4} className="expanded">
                        <h5>{product.ProductName} Description : </h5>
                        {product.QuantityPerUnit}
                      </td>
                    </tr>
                  ) : null}
                </>
              );
            })}
        </tbody>
      </table>
    </div>
  );
};
