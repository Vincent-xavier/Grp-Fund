import { Outlet, RouteObject } from "react-router-dom";

import Login from "../pages/auth/index";

const publicRoutes: RouteObject = {
  path: "/",
  children: [
    {
      path: "/",
      element: <Outlet />,
      children: [
        {
          path: "/",
          element: <Login />,
        },
      ],
    },
  ],
};
export default publicRoutes;
