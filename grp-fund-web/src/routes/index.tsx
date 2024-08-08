import { useRoutes } from "react-router-dom";
import publicRoutes from "./publicRoutes";
import authRoutes from "./authRoutes";

const Routes = () => {
  return useRoutes([publicRoutes, authRoutes]);
};

export default Routes;
