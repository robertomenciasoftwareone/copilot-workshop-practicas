function getUniqueUsers(users) {
    return Array.from(new Map(users.map(user => [user.email, user])).values());
}

const users = [{id:1,email:'a@test.com',name:'Ana'},{id:2,email:'b@test.com',name:'Bob'},{id:3,email:'a@test.com',name:'Ana2'},{id:4,email:'c@test.com',name:'Clara'}];
console.log(getUniqueUsers(users));
