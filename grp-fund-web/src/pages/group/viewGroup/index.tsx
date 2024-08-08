import { Button, Card } from "antd";

const GroupDetails = () => {
  return (
    <Card
      title="Group Details"
      extra={
        <Button size="small" type="primary" href="add-group">
          Add Group
        </Button>
      }
    ></Card>
  );
};

export default GroupDetails;
