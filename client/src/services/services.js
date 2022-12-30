import axios from "axios";

export const getProducts = async () => {
  let response = await axios.get("http://localhost:7147/api/Products");
  return Object.values(response.data);
};

export const addCostumerMessage = async (CostumerMessage) => {
  await axios.post("http://localhost:7147/api/Products", CostumerMessage);
};

// export const getProducts = async () => {
//   return await axios
//     .get("http://localhost:7147/api/Products")
//     .then((response) => {
//       return Object.values(response.data);
//     });
// };
