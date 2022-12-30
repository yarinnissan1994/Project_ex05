import axios from "axios";

export const getProducts = async () => {
  let response = await axios.get("http://localhost:7147/api/Users/get");
  return Object.values(response.data);
};

export const addCostumerMessage = async (CostumerMessage) => {
  await axios.post(
    "http://localhost:7147/api/Users/post-message",
    CostumerMessage
  );
};

export const UpdateProduct = async (ProductToUpdate) => {
  console.log(ProductToUpdate);
  await axios.post("http://localhost:7147/api/Users/update", ProductToUpdate);
};

export const deleteProduct = async (ProductId) => {
  try {
    let endPoint = `http://localhost:7147/api/Users/delete/${ProductId}`;
    await axios.delete(endPoint);
  } catch (error) {
    console.error(error);
  }
};
