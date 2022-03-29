import { api } from './config';

export default {
    
    get: () => {
        return api.get('students')
    },
    add: (student) => {
        return api.post('students', student)
    },
    update: (student) => {
        return api.put(`students/${student.id}`, student)
    },
    delete : (id) => {
        return api.delete(`students/${id}`)
    }


}