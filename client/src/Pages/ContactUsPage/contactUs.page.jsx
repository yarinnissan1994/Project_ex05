import React, { useState } from "react";
import { addCostumerMessage } from "../../services/services";
import "./contactUs.css";

export const ContactUsPage = () => {
  const [name, setName] = useState("");
  const [message, setMessage] = useState("");
  const [phone, setPhone] = useState("");
  const [email, setEmail] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    const costumerMessage = { name, message, phone, email };
    if (name === "" || message === "" || phone === "" || email === "") {
      alert("Please fill all fields");
    } else {
      addCostumerMessage(costumerMessage);
      alert("Message Arraived");
      setEmail("");
      setMessage("");
      setName("");
      setPhone("");
    }
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name" className="frm-lbl">
            Costumer Name:
          </label>
          <input
            type="text"
            className="form-control"
            id="name"
            value={name}
            onChange={(event) => setName(event.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="message" className="frm-lbl">
            Message:
          </label>
          <textarea
            className="form-control"
            id="message"
            value={message}
            onChange={(event) => setMessage(event.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="phone" className="frm-lbl">
            Phone Number:
          </label>
          <input
            type="tel"
            className="form-control"
            id="phone"
            value={phone}
            onChange={(event) => setPhone(event.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="email" className="frm-lbl">
            Email Address:
          </label>
          <input
            type="email"
            className="form-control"
            id="email"
            value={email}
            onChange={(event) => setEmail(event.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Submit
        </button>
      </form>
    </div>
  );
};
