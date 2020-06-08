import React from 'react';
import {
    Form,
    Input,
    Button,
    InputNumber,
} from 'antd'; 
import { OrderApi } from "../order/api";
import { Api } from "./api";


export class Spectacle extends React.Component {
    state = {
        user: {},
        spectacle: {},
        order: {}
    }

    async componentDidMount() {
        var id = this.props.match.params.id;
        const user = localStorage.getItem('user');
         
        const res = await Api.getSpectacle(id);
        debugger;
        this.setState(            { 
                spectacle: res,
                user: JSON.parse(user) });
    }
 

    // todo add validation
    handleSave() {
        // todo validation 
        this.state.order.spectacleId = this.state.spectacle.id;
        OrderApi.createOrder(this.state.order);
        this.props.history.push('/');
    }

    changeTickets = (tickets) => {
        this.setState(prevState => ({
            ...prevState,
            order: {
                ...prevState.order,
                tickets
            }
        }
        ));
    }

    changeEmail = (email) => {
        this.setState(prevState => ({
            ...prevState,
            order: {
                ...prevState.order,
                email
            }
        }
        ));
    }

    render() {
        return (
            <>
                <h1>{this.state.name}</h1>
                <Form
                    labelCol={{
                        span: 4,
                    }}
                    wrapperCol={{
                        span: 14,
                    }}
                    layout="horizontal"
                    size="large"
                >

                    <Form.Item label="Email">
                        <Input onChange={_ => this.changeEmail(_.target.value)} value={this.state.user?.username} />
                    </Form.Item>

                    <Form.Item label="Amount of Tickets">
                        <InputNumber
                            onChange={this.changeTickets}
                            max={this.state.spectacle.tickets}
                            min={1} />
                    </Form.Item>
                    <Form.Item label="Actions">
                        <Button onClick={() => this.handleSave()}>Order</Button>
                    </Form.Item>
                </Form>
            </>

        );

    }

}