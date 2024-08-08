import { Button, Layout, Menu, MenuProps, theme } from "antd";
import { useState } from "react";

const { Header, Sider, Content } = Layout;
import { AiOutlineMenuFold, AiOutlineMenuUnfold } from "react-icons/ai";
import { BiArrowBack } from "react-icons/bi";
import { FaUsers } from "react-icons/fa";
import { HiArrowSmLeft, HiArrowSmRight } from "react-icons/hi";
import { IoDesktopOutline, IoFileTrayOutline } from "react-icons/io5";
import { MdPieChartOutlined } from "react-icons/md";
import { TiUserOutline } from "react-icons/ti";

import { Link, Outlet } from "react-router-dom";

type MenuItem = Required<MenuProps>["items"][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[]
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem(<Link to="/group">Group</Link>, "1", <MdPieChartOutlined />),
  getItem("Option 2", "2", <IoDesktopOutline />),
  getItem("User", "sub1", <TiUserOutline />, [
    getItem("Tom", "3"),
    getItem("Bill", "4"),
    getItem("Alex", "5"),
  ]),
  getItem("Team", "sub2", <FaUsers />, [
    getItem("Team 1", "6"),
    getItem("Team 2", "8"),
  ]),
  getItem("Files", "9", <IoFileTrayOutline />),
];

const MainLayout = () => {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <Layout
      style={{
        minHeight: "100vh ",
        padding: 0,
        width: "100%",
      }}
    >
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div className="logo-containner">
          <div className="demo-logo-vertical" />
          <Button
            className="toggle-button"
            icon={collapsed ? <HiArrowSmRight /> : <HiArrowSmLeft />}
            onClick={() => setCollapsed(!collapsed)}
          />
        </div>
        <Menu
          defaultSelectedKeys={["1"]}
          mode="inline"
          items={items}
          theme="dark"
        />
      </Sider>
      <Layout>
        <Header style={{ padding: 0 }}>{/* Your Header Content */}</Header>
        <Content
          style={{
            margin: "12px",
          }}
        >
          <Outlet />
        </Content>
      </Layout>
    </Layout>
  );
};

export default MainLayout;
