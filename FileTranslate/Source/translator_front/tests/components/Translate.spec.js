import { MountHelper } from "../TestHelper.js";
import Translate from "@/views/Translator.vue";
import Nuevo from "@/views/Nuevo.vue";
import Login from "@/views/Login.vue";
import Vue from "vue";



describe("Translate.vue", () => {
    let wrapper;
    const props = {};

    beforeAll(() => {
        wrapper = MountHelper.GetMountWrapper(Translate, props);
    });

    async function ClickOnSaveButton() {
        const btnSave = wrapper.find("#traduccion");
        await btnSave.trigger("click");
    }

    function ValidateFields() {
        const formFile = wrapper.find("#formFile");
        expect(formFile.exists()).toBe(true);

        const Translatefrom = wrapper.find("#Translatefrom");
        expect(Translatefrom.exists()).toBe(true);

        const TranslateInto = wrapper.find("#TranslateInto");
        expect(TranslateInto.exists()).toBe(true);


        const btnSave = wrapper.find("#buttonSave");
        expect(btnSave.exists()).toBe(true);
    }


    it("new employees", async() => {

        const names = wrapper.find("#Translatefrom");
        await names.setValue("Español");

        const birthdate = wrapper.find("#TranslateInto");
        await birthdate.setValue("English");


        await ClickOnSaveButton();
        await Vue.nextTick();

    });
});



describe("Nuevo.vue", () => {
    let wrapper;
    const props = {};

    beforeAll(() => {
        wrapper = MountHelper.GetMountWrapper(Nuevo, props);
    });

    async function ClickOnSaveButton() {
        const btnButton = wrapper.find("#btnButton");
        await btnButton.trigger("click");
    }

    function ValidateFields() {
        const name = wrapper.find("#name");
        expect(name.exists()).toBe(true);

        const lastName = wrapper.find("#lastName");
        expect(lastName.exists()).toBe(true);

        const email = wrapper.find("#email");
        expect(email.exists()).toBe(true);

        const password = wrapper.find("#password");
        expect(password.exists()).toBe(true);


        const btnSave = wrapper.find("#btnsave");
        expect(btnSave.exists()).toBe(true);
    }


    it("new User", async() => {

        const names = wrapper.find("#name");
        await names.setValue("Johan");

        const lastName = wrapper.find("#lastName");
        await lastName.setValue("Garavito");

        const email = wrapper.find("#email");
        await email.setValue("johangaravitosantiago@gmail.com");

        const password = wrapper.find("#password");
        await password.setValue("santiago");

        await ClickOnSaveButton();
        await Vue.nextTick();

    });
});


describe("Login.vue", () => {
    let wrapper;
    const props = {};

    beforeAll(() => {
        wrapper = MountHelper.GetMountWrapper(Login, props);
    });

    async function ClickOnSaveButton() {
        const btnSave = wrapper.find("#btnLogin");
        await btnSave.trigger("click");
    }

    function ValidateFields() {
        const login = wrapper.find("#login");
        expect(login.exists()).toBe(true);

        const password = wrapper.find("#password");
        expect(password.exists()).toBe(true);


        const btnLogin = wrapper.find("#btnLogin");
        expect(btnLogin.exists()).toBe(true);
    }


    it("Login", async() => {

        const names = wrapper.find("#login");
        await names.setValue("Español");

        const birthdate = wrapper.find("#password");
        await birthdate.setValue("English");


        await ClickOnSaveButton();
        await Vue.nextTick();

    });
});