import { useAuth0 } from "@auth0/auth0-react";
import { Route, Routes } from "react-router-dom";
import "./App.css";
import { NavbarComponent } from "./Components/Navbar/navbar.component";
import { AboutPage } from "./Pages/AboutPage/about.page";
import { ContactUsPage } from "./Pages/ContactUsPage/contactUs.page";
import { HomePage } from "./Pages/HomePage/home.page";
import { LoginPage } from "./Pages/LoginPage/login.page";
import { ProductsPage } from "./Pages/ProductsPage/products.page";
import { ProfilePage } from "./Pages/ProfilePage/profile.page";

function App() {
  const { isAuthenticated, isLoading } = useAuth0();
  if (!isLoading) {
    if (isAuthenticated) {
      return (
        <div className="App">
          <NavbarComponent />
          <Routes>
            <Route path="/" element={<HomePage />}></Route>
            <Route path="/about" element={<AboutPage />}></Route>
            <Route path="/contact-us" element={<ContactUsPage />}></Route>
            <Route path="/products" element={<ProductsPage />}></Route>
            <Route path="/profile" element={<ProfilePage />}></Route>
          </Routes>
        </div>
      );
    } else {
      return <LoginPage />;
    }
  } else {
    return <h1>loading</h1>;
  }
}

export default App;
