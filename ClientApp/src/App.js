import React, { useEffect } from 'react';
import 'antd/dist/antd.css';

import { Switch, Route, Redirect, BrowserRouter } from 'react-router-dom';
import { Layout } from 'antd';

import { Theater } from './features/theater/index';
import { Spectacle } from './features/theater/spectacle';
import { SpectacleBuilder } from './features/theater/spectacleBuilder';
import { Login } from "./features/auth/index";
import './App.css'; 

const { Content } = Layout;

function App() {
   
  return (
    <Layout className="app">
      <BrowserRouter>
        {/* <Header />  todo */}
        <Switch>
          <Route exact path="/" component={Theater} />
          <Route exact path="/auth" component={Login} />
          <Route path="/spectacles-builder/:id" component={SpectacleBuilder} />
          <Route path="/spectacles/:id" component={Spectacle} />
        </Switch>
      </BrowserRouter>
    </Layout>
  );
}

export default App;
