//import Vue from "vue";
import { createLocalVue, RouterLinkStub, mount } from "@vue/test-utils";

const MountHelper = {
    AddElemWithDataAppToBody() {
        const app = document.createElement("div");
        app.setAttribute("data-app", true);
        app.id = "root";
        document.body.append(app);
    },
    GetMountWrapper(component, props = {}, mockOptions = {}) {
        const localVue = createLocalVue();




        this.AddElemWithDataAppToBody();

        const wrapper = mount(component, {
            localVue,
            stubs: {
                RouterLink: RouterLinkStub,
            },
            propsData: props,
        });
        return wrapper;
    }
};

export { MountHelper };