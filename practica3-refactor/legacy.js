function getUniqueUsers(users) {
    const unique = [];
    for (let i = 0; i < users.length; i++) {
        let isUnique = true;
        for (let j = 0; j < unique.length; j++) {
            if (users[i].email === unique[j].email) {
                isUnique = false;
                break;
            }
        }
        if (isUnique) unique.push(users[i]);
    }
    return unique;
}
const users = [{id:1,email:'a@test.com',name:'Ana'},{id:2,email:'b@test.com',name:'Bob'},{id:3,email:'a@test.com',name:'Ana2'},{id:4,email:'c@test.com',name:'Clara'}];
console.log(getUniqueUsers(users));
