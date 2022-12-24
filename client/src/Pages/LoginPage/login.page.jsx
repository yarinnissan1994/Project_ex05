import { useAuth0 } from "@auth0/auth0-react";
import React from "react";

export const LoginPage = () => {
  return LoginButton();
};

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0();

  return (
    <button onClick={() => loginWithRedirect("http://localhost:3000/")}>
      Log In
    </button>
  );
};
