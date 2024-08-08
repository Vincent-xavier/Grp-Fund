import React, { useState } from "react";
import { Form, Input, DatePicker, Tag, Button, Card } from "antd";

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
interface GroupDetailsFormValues {
  groupName: string;
  description: string;
  creationDate: string;
}
const AddGroup = () => {
  const [form] = Form.useForm();
  const [requiredMark, setRequiredMarkType] =
    useState<RequiredMark>("customize");

  const onFinish = (values: GroupDetailsFormValues) => {
    console.log("Form Values:", values);
    // You can submit the form data here
  };
  return (
    <Card title="Add Group">
      <Form
        form={form}
        onFinish={onFinish}
        layout="vertical"
        requiredMark={
          requiredMark === "customize" ? customizeRequiredMark : requiredMark
        }
      >
        <Form.Item
          name="groupName"
          label="Group Name"
          rules={[{ required: true, message: "Please enter the group name" }]}
        >
          <Input placeholder="Enter the group name" />
        </Form.Item>

        <Form.Item
          name="description"
          label="Description"
          rules={[{ required: true, message: "Please enter a description" }]}
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
    </Card>
  );
};

export default AddGroup;
