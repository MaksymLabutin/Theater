import React from 'react';
import {
    Form,
    Input,
    Button,
    DatePicker,
    InputNumber,
} from 'antd';
import { Link } from 'react-router-dom';

import moment from 'moment';
import { Api } from "./api";


export class SpectacleBuilder extends React.Component {

    state = {
        isEdit: false,
        spectacle: {}
    };

    async componentDidMount() {
        
        if(!this.isAdmin()) this.props.push("/");
        var id = this.props.match.params.id;
        if(id == "new") return;
        if (id) {
            const res = await Api.getSpectacle(id);
            this.setState({
                isEdit: true,
                spectacle: res
            });
        }
    }

    isAdmin = () => {
        const user = localStorage.getItem('user');
        return JSON.parse(user).isAdmin;
    }

    // todo add validation
    handleSave() {
        if (this.state.isEdit) {
            Api.updateSpectacle(this.state.spectacle)
        } else {
            Api.createSpectacle(this.state.spectacle)
        }

        this.props.history.push('/');
    }

    changeName = (name) => {
        this.setState(prevState => ({
            spectacle: {
                ...prevState.spectacle,
                name: name
            }
        }
        ));
    }

    changeDate = (date, dateString) => {
        this.setState(prevState => ({
            spectacle: {
                ...prevState.spectacle,
                date: dateString
            }
        }
        ));
    }

    
    changeTickets = (tickets) => {
        this.setState(prevState => ({
            spectacle: {
                ...prevState.spectacle,
                tickets: tickets
            }
        }
        ));
    }
    render() {
        return (
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
                <Form.Item label="Name">
                    <Input onChange={_ => this.changeName(_.target.value)} value={this.state.spectacle.name} />
                </Form.Item>
                {/* TODO add time */}
                <Form.Item label="Date">
                    <DatePicker onChange={this.changeDate} defaultValue={moment(this.state.spectacle.date)} />
                </Form.Item>
                <Form.Item label="Tickets">
                    <InputNumber onChange={this.changeTickets} value={this.state.spectacle.tickets} />
                </Form.Item>
                <Form.Item label="Actions">
                    <Button onClick={this.handleSave.bind(this)}>Save</Button>
                    <Button>
                        <Link to={`/`}>
                            Cancel
                        </Link>
                    </Button>
                </Form.Item>
            </Form>
        );

    }

}