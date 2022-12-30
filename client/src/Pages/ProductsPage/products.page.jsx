import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { deleteProduct, getProducts } from "../../services/services";
import "./products.css";

export const ProductsPage = () => {
  const navigate = useNavigate();
  const [productsData, setProductsData] = useState([]);

  const getProductsFromDB = async () => {
    let res = await getProducts();
    setProductsData(res);
    console.log(res);
  };
  useEffect(() => {
    getProductsFromDB();
  }, []);

  const [expanded, setExpanded] = useState(false);
  const [key, setKey] = useState(null);

  const handleClick = (proKey) => {
    setExpanded(!expanded);
    setKey(proKey);
  };

  const handleUpadate = (Product) => {
    navigate("/edit-product", {
      state: {
        Product,
      },
    });
  };

  const habdleDelete = async (productID) => {
    await deleteProduct(productID);
    setExpanded(!expanded);
    getProductsFromDB();
  };

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
                      <td>
                        <button
                          className="btn btn-warning"
                          onClick={() => {
                            handleUpadate(product);
                          }}
                        >
                          Edit Item
                        </button>
                      </td>
                      <td colSpan={2} className="expanded">
                        <h5>{product.ProductName} Description : </h5>
                        {product.QuantityPerUnit}
                      </td>
                      <td>
                        <button
                          className="btn btn-danger"
                          onClick={() => {
                            habdleDelete(product.ProductID);
                          }}
                        >
                          Remove Item
                        </button>
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
