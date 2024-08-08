import { Button, Layout, Menu, MenuProps, Tag } from "antd";
import { useState } from "react";

const { Header, Sider, Content } = Layout;
import { AiOutlineMenuFold, AiOutlineMenuUnfold } from "react-icons/ai";
import { FaUsers } from "react-icons/fa";
import { IoDesktopOutline, IoFileTrayOutline } from "react-icons/io5";
import { MdPieChartOutlined } from "react-icons/md";
import { TiUserOutline } from "react-icons/ti";

import { Form, Input, DatePicker } from "antd";

type MenuItem = Required<MenuProps>["items"][number];

interface GroupDetailsFormValues {
  groupName: string;
  description: string;
  creationDate: string;
}

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

type RequiredMark = boolean | "optional" | "customize";

const customizeRequiredMark = (
  label: React.ReactNode,
  { required }: { required: boolean }
) => (
  <>
    {required ? (
      <Tag color="error">Required</Tag>
    ) : (
      <Tag color="warning">optional</Tag>
    )}
    {label}
  </>
);

const MainLayout = () => {
  const [collapsed, setCollapsed] = useState(false);

  const [form] = Form.useForm();
  const [requiredMark, setRequiredMarkType] =
    useState<RequiredMark>("customize");

  const onFinish = (values: GroupDetailsFormValues) => {
    console.log("Form Values:", values);
    // You can submit the form data here
  };
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
          <button
            type="button"
            className="ant-btn toggle-button ant-btn-link "
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
              className="lucide lucide-chevron-left "
            >
              <path d="m15 18-6-6 6-6"></path>
            </svg>
          </button>
        </div>
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
          <Form
            form={form}
            layout="vertical"
            onFinish={onFinish}
            style={{ maxWidth: "600px", margin: "0 auto" }}
            requiredMark={
              requiredMark === "customize"
                ? customizeRequiredMark
                : requiredMark
            }
          >
            <Form.Item
              name="groupName"
              label="Group Name"
              rules={[
                { required: true, message: "Please enter the group name" },
              ]}
            >
              <Input placeholder="Enter the group name" />
            </Form.Item>

            <Form.Item
              name="description"
              label="Description"
              rules={[
                { required: true, message: "Please enter a description" },
              ]}
            >
              <Input.TextArea placeholder="Enter a brief description of the group" />
            </Form.Item>

            <Form.Item
              name="creationDate"
              label="Creation Date"
              rules={[
                { required: true, message: "Please select the creation date" },
              ]}
            >
              <DatePicker style={{ width: "100%" }} />
            </Form.Item>

            <Form.Item>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Content>
      </Layout>
    </Layout>
  );
};

export default MainLayout;
