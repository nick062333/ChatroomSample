import { createStore } from 'idb-keyval';

const customStore = createStore('message', 'message_store');

export default customStore