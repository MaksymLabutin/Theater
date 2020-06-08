import React from 'react';
import { Link } from 'react-router-dom';
import { Table, Button, Input, Space, Tooltip } from 'antd';
import { EditOutlined, SearchOutlined, StepForwardOutlined } from '@ant-design/icons';

import { DatePicker } from 'antd';

import { Api } from "./api";

export class Theater extends React.Component {
    state = {
        spectacles: [],
        total: 0,
        isAdmin: false
        //todo
        // filteredInfo: {
        //     name: "",
        //     date: ""
        // }
    }

    async componentDidMount() {
        const res = await Api.getSpectacles();
        this.setState({
            spectacles: res.items,
            total: res.total,
            isAdmin: this.isAdmin()
        });
    }

    isAdmin = () => {
        const user = localStorage.getItem('user');
        return JSON.parse(user).isAdmin;
    }

    filterByDate = async (date, dateString) => {
        const res = await Api.getSpectacles({ date: dateString });
        this.setState({
            spectacles: res.items,
            total: res.total
        });
    }

    getColumnSearchProps = () => ({
        filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters }) => (
            <div style={{ padding: 8 }}>
                <Input
                    placeholder="Name"
                    onChange={e => setSelectedKeys(e.target.value ? [e.target.value] : [])}
                    onPressEnter={() => this.handleSearchName(selectedKeys[0], confirm)}
                    style={{ width: 188, marginBottom: 8, display: 'block' }}
                    value={selectedKeys[0]}
                />
                <Button
                    type="primary"
                    onClick={() => this.handleSearchName(selectedKeys[0], confirm)}
                    icon={<SearchOutlined />}
                    size="small"
                    style={{ width: 90, marginRight: 8 }}
                >
                    Search
            </Button>
                <Button
                    onClick={() => {
                        this.handleReset(clearFilters)
                    }}
                    size="small"
                    style={{ width: 90 }}
                >
                    Reset
            </Button>
            </div>
        ),
        filterIcon: () => (
            <SearchOutlined
                style={{
                    color: '#1890ff'
                }}
            />
        ),
    });

    handleSearchName = async (name, confirm) => {
        const res = await Api.getSpectacles(name);
        this.setState({
            spectacles: res.items,
            total: res.total
        });
        confirm();
    }

    handleReset = async (clearFilters) => {
        clearFilters();
        const res = await Api.getSpectacles();
        this.setState({
            spectacles: res.items,
            total: res.total
        });
    };

    clearFilters = async () => {
        const res = await Api.getSpectacles();
        this.setState({
            spectacles: res.items,
            total: res.total
        });
    };


    render() {

        const dateFormat = 'YYYY/MM/DD';
        const columns = [
            {
                title: 'Name',
                dataIndex: 'name',
                key: 'name',
                ...this.getColumnSearchProps(),
            },
            {
                title: 'Date',
                dataIndex: 'date',
                key: 'date'
            },
            {
                title: 'Tickets',
                dataIndex: 'tickets',
                key: 'tickets'
            },
            {
                title: 'Actions',
                key: 'actions',
                render: (text, record) => (
                    <span className="actions">
                        {this.state.isAdmin &&
                            <Tooltip placement="top" title="Edit" arrowPointAtCenter>
                                <Button type="link">
                                    <Link to={`/spectacles-builder/${record.id}`}>
                                        <EditOutlined style={{ fontSize: '18px' }} />
                                    </Link>
                                </Button>
                            </Tooltip>
                        }

                        <Tooltip placement="top" title="Order" arrowPointAtCenter>
                            <Button type="link">
                                <Link to={`/spectacles/${record.id}`}>
                                    <StepForwardOutlined style={{ fontSize: '18px' }} />
                                </Link>
                            </Button>
                        </Tooltip>
                    </span>
                ),
            },
        ];

        return (
            <>
                <Space style={{ marginBottom: 16 }}>
                    <DatePicker format={dateFormat} onChange={this.filterByDate} />
                    <Button onClick={this.clearFilters}>Clear filters</Button>
                    {this.state.isAdmin &&
                        <Button >    <Link to={`/spectacles-builder/new`}>Create</Link></Button>

                    }
                </Space>

                {this.state && this.state.spectacles && (
                    <Table
                        columns={columns}
                        dataSource={this.state.spectacles}
                        total={this.state.total}
                    />
                )}
            </>
        );

    }
}

// const mapStateToProps = state => {
//     return state?.spectacles;
// };

// export const Theater = connect(null, {fetchSpectacles})(TheaterContainer);

// export default connect(null, {fetchSpectacles})(TheaterContainer); 