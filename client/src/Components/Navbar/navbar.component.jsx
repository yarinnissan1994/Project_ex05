import React from "react";
import { Link } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import InfoIcon from "@mui/icons-material/Info";
import CallIcon from "@mui/icons-material/Call";
import RedeemIcon from "@mui/icons-material/Redeem";
import MeetingRoomIcon from "@mui/icons-material/MeetingRoom";
import "./navbar.css";
import { useAuth0 } from "@auth0/auth0-react";

export const NavbarComponent = (props) => {
  const { user, logout } = useAuth0();
  return (
    <div className="container">
      <ul className="menu">
        <li>
          <Link to="/">
            <HomeIcon />
            <label className="Link-lbl">Home</label>
          </Link>
        </li>
        <li>
          <Link to="/about">
            <InfoIcon />
            <label className="Link-lbl">About</label>
          </Link>
        </li>
        <li>
          <Link to="/contact-us">
            <CallIcon />
            <label className="Link-lbl">Contact Us</label>
          </Link>
        </li>
        <li>
          <Link to="/products">
            <RedeemIcon />
            <label className="Link-lbl">Products</label>
          </Link>
        </li>
        <li className="yarin-li">
          <Link to="/profile">
            <img src={user.picture} alt={user.name} className="profile-img" />
            <br></br>
            <label className="Link-lbl">{user.name}</label>
          </Link>
        </li>
        <li>
          <Link>
            <MeetingRoomIcon />
            <label
              onClick={() => logout({ returnTo: window.location.origin })}
              className="Link-lbl"
            >
              LogOut
            </label>
          </Link>
        </li>
      </ul>
    </div>
  );
};
