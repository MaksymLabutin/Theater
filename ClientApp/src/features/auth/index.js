import React from 'react';
import ReactDOM from 'react-dom';
import 'antd/dist/antd.css'; 
import { Form, Input, Button, Checkbox } from 'antd';  

import {AuthApi} from "./api";

const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 8,
    },
};
const tailLayout = {
    wrapperCol: {
        offset: 8,
        span: 8,
    },
};



export class Login extends React.Component {

    state = {
        userName: "",
        password: ""
    }

    changePassword = (pwd) => {
        this.setState(prevState => ({
            ...prevState,
            password: pwd
        }))
    }

    changeUserName = (userName) => {
        this.setState(prevState => ({
            ...prevState,
            userName
        }))
    }

    handleSubmit = async () => { 
        var user = await AuthApi.login(this.state);
        localStorage.setItem('user', JSON.stringify(user)); 
        this.props.history.push("/");
    }

    render() {
        return (
            <Form
                {...layout}
                name="basic"
                initialValues={{
                    remember: true,
                }}
            >
                <Form.Item
                    label="UserName"
                    name="userName"
                    rules={[
                        {
                            required: true,
                            message: 'Please input your User Name!',
                        },
                    ]}
                >
                    <Input onChange={_ => this.changeUserName(_.target.value)} />
                </Form.Item>

                <Form.Item
                    label="Password"
                    name="password"
                    rules={[
                        {
                            required: true,
                            message: 'Please input your password!',
                        },
                    ]}
                >
                    <Input.Password onChange={_ => this.changePassword(_.target.value)} />
                </Form.Item>

                <Form.Item {...tailLayout} name="remember" valuePropName="checked">
                    <Checkbox>Remember me</Checkbox>
                </Form.Item>

                <Form.Item {...tailLayout}>
                    <Button type="primary" htmlType="submit" onClick={this.handleSubmit}>
                        Submit
        </Button>
                </Form.Item>
            </Form >
        );
    }
}; 