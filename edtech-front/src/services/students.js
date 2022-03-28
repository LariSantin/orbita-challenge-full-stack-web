import { server } from './config';

export default {
    
    get: () => {
        return server.get('students')
    },
    getById: () => {
        return server.get()
    },
    add: (student) => {
        return server.post('students', student)
    }


}