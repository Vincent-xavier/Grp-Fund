import { RouteObject } from "react-router-dom";

import MainLayout from "../layout";

// group
import AddGroup from "../pages/group/AddGroup";
import GroupDetails from "../pages/group/viewGroup";

const authRoutes: RouteObject = {
  path: "/",
  children: [
    {
      path: "/",
      element: <MainLayout />,
      children: [
        {
          path: "dashboard",
          element: <div>Dashboard</div>,
        },
        {
          path: "group",
          element: <GroupDetails />,
        },
        {
          path: "add-group",
          element: <AddGroup />,
        },
        {
          path: "master",
          children: [
            {
              path: "category",
              element: <div>Category</div>,
            },
          ],
        },
      ],
    },

    { path: "*", element: <div>404</div> },
  ],
};

export default authRoutes;
