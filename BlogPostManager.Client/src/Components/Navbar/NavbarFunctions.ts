import {  useNavigate } from "react-router";


export function Signout() {
    const navigate = useNavigate();
    navigate("/");
}