import React from 'react';
import {ReactComponent as Logo} from '../../../../assets/header/logo.svg';
import {AppMenu} from './Menu';
import {ChangeLocale, TI18n} from "../../../../i18n";
import {SocialLinks} from "../../../../components/SocialLinks";
import '../styles/header.scss'
import {BottomContent} from "./BottomContent";

interface IPropTypes {
}

const AdminHeader: React.FC<IPropTypes> = () => {
    return (
        <header className="dog-background">
            <div className="header">
                <div className="logo-main">
                    <div className="logo"><Logo/></div>
                    <div className="logo-text">
                        <TI18n keyStr="headerTitle" default="Спасение животных в Харькове"/>
                    </div>
                </div>
                <div className="logo-main">
                    <div className="logo-text">
                        ADMIN
                    </div>
                </div>
                <SocialLinks/>
                <div className="change-locale">
                    <ChangeLocale/>
                </div>
            </div>
            <AppMenu/>
            <BottomContent/>
        </header>
    )
};

export default AdminHeader;
