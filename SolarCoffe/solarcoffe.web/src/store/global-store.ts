import { InventoryService } from "@/services/InventoryService.";
import { IInventoryTimeline } from "@/types/InventoryGraph";
import { make } from "vuex-pathify";

class GlobalStore {
    snapshotTimeline: IInventoryTimeline = {

        productInventorySnapshots: [],
        timeline: []
    };
    isTimelineBuild: Boolean = false;
}

const state = new GlobalStore();

const mutations = make.mutations(state);

const actions = {

    async assignSnapshots({ commit }) {
        const inventoryService = new InventoryService();
        let response = await inventoryService.GetSnapshotHistory();
        let timeline: IInventoryTimeline = {
            productInventorySnapshots: response.productInventorySnapshots,
            timeline: response.timeline
        };
        commit('SET_SNAPSHOT_TIMELINE', timeline);
        commit('SET_IS_TIMELINE_BUILT', true);



    }
}

const getters = {};

export default {
    state, mutations, actions, getters
}