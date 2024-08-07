import { Button, Layout, Menu, MenuProps } from "antd";
import { useState } from "react";

const { Header, Sider, Content } = Layout;
import { AiOutlineMenuFold, AiOutlineMenuUnfold } from "react-icons/ai";
import { FaUsers } from "react-icons/fa";
import { IoDesktopOutline, IoFileTrayOutline } from "react-icons/io5";
import { MdPieChartOutlined } from "react-icons/md";
import { TiUserOutline } from "react-icons/ti";

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
  getItem("Option 1", "1", <MdPieChartOutlined />),
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
    <Layout style={{ minHeight: "100vh", padding: 0, width: "100%" }}>
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div className="demo-logo-vertical" />
        <Menu
          theme="dark"
          defaultSelectedKeys={["1"]}
          mode="inline"
          items={items}
        />
      </Sider>
      <Layout>
        <Header style={{ padding: 0 }}>
          <Button
            type="text"
            icon={collapsed ? <AiOutlineMenuUnfold /> : <AiOutlineMenuFold />}
            onClick={() => setCollapsed(!collapsed)}
            style={{
              fontSize: "16px",
              width: 64,
              height: 64,
              color: "#fff",
            }}
          />
        </Header>
        <Content
          style={{
            margin: "24px 16px",
            padding: 24,
            minHeight: 280,
          }}
        >
          Content
        </Content>
      </Layout>
    </Layout>
  );
};

export default MainLayout;
