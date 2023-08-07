<template>
    <div class="w-full pb-8 px-3">
        <div class="top flex flex-col items-center">
            
            <div class="w-full main-form p-4 flex flex-column items-center md:w-6/12 mx-auto">
                <h1 class="bold text-xl form-title text-center">Employee Data</h1>

                <div class="w-full">
                    <label for="" class="font-semibold">Employee Name</label>
                    <select name="" id="" class="p-2 rounded w-full normal-input">
                        <option value="Employee">Employee 1</option>
                        <option value="Employee">Employee 1</option>
                    </select>
                </div>

                <div class="w-full">
                    <label for="" class="font-semibold">Job Title</label>
                    <input type="text" class="normal-input p-2 rounded w-full input">
                </div>

                <div class="w-full">
                    <label for="" class="font-semibold">Department</label>
                    <select name="" id="" class="p-2 rounded w-full normal-input">
                        <option value="Employee">Engineering</option>
                        <option value="Employee">Operations</option>
                    </select>
                </div>

                <div class="w-full">
                    <label for="" class="font-semibold">Grade</label>
                    <input type="text" class="normal-input p-2 rounded w-full input">
                </div>

                
                <div class="w-full">
                    <label for="" class="font-semibold">Line Manager</label>
                    <select name="" id="" class="p-2 rounded w-full normal-input">
                        <option value="Employee">Mr 1</option>
                        <option value="Employee">Mr 2</option>
                    </select>
                </div>

                <div class="w-full">
                    <label for="" class="font-semibold">Date of Employment</label>
                    <input type="date" class="normal-input p-2 rounded w-full input">
                </div>

                <div class="w-full">
                    <label for="" class="font-semibold">Date of Initiation</label>
                    <input type="date" class="normal-input p-2 rounded w-full input">
                </div>

                <h1 class="bold text-xl form-title text-center">Performance Objectives and Ratings</h1>

                <div class="w-full">
                    <div class="w-full py-4 flex justify-between items-center mb-8" v-for="(question, index) in questions" :key="index">
                        <div class="w-8/12">
                            <div class="w-full">
                                <!-- <label for="" class="font-semibold">Performance Objective 1</label> -->
                                <textarea v-model="question.label" class="normal-input p-2 rounded w-full input"></textarea>
                            </div>
                            <div class="w-full">
                                <!-- <label for="" class="font-semibold">Rating</label> -->
                                <select name="" v-model="question.rating" id="" class="p-2 rounded w-full input">
                                    <option >Select Rating</option>
                                    <option value="Exceeds Expectation">Exceeds Expectation</option>
                                    <option value="Exceptional">Exceptional</option>
                                    <option value="Meet Expectation">Meet Expectation</option>
                                    <option value="Outsatnding">Outsatnding</option>
                                    <option value="Need Improvement">Need Improvement</option>
                                </select>
                            </div>
                        </div>
                        <div class="w-4/12 flex justify-end items-center">
                            <a class="hover font-semibold text-sm text-red-400" @click="removeQuestion(index)">Remove</a>
                        </div>
                    </div>

                    <div class="w-full">
                        <div class="w-full flex justify-between">
                            <a class="hover font-semibold text-sm add-btn flex items-center" @click="addQuestion()">
                                <span class="px-2">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24" fill="none">
<path d="M6.5 12H18.5M12.5 18V6" stroke="#5C7D27" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
</svg>
                                </span> 
                                <span>Add performance objectives</span>
                            </a>
                            <a class="hover font-semibold text-sm add-btn flex items-center">
                                <span class="px-2">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24" fill="none">
<path d="M6.5 12H18.5M12.5 18V6" stroke="#5C7D27" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
</svg>
                                </span> 
                                <span>Add from existing</span>
                            </a>
                        </div>
                    </div>
                </div>

                <div class="w-full flex justify-center items-center">
                    <button class="font-semibold hover submit px-4 py-2 text-white text-lg">Submit</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            questions: [ ]
        }
    },

    methods: {
        addQuestion() {
            this.questions.push({ label: '', rating: '' })
        },

        removeQuestion(index) {
            this.questions.splice(index, 1)
        }
    }
    
}
</script>

<style scoped>
    .form-title {
        color: #000;
        font-size: 25px;
        font-style: normal;
        font-weight: 600;
        line-height: normal;
    }

    .main-form {
        display: inline-flex;
        flex-direction: column;
        align-items: center;
        gap: 16px;
        box-shadow: 1px 2px 2px 2px #8080807a;
        border-radius: 8px;
    }

    .normal-input {
        border-radius: 8px;
        border: 1px solid #9ab0b047;
        outline: none;
        background: #F6FAFA;
    }

    .input:focus {
        outline: none;
        border-radius: 8px;
    }

    .submit {
        border-radius: 8px;
        background: #69882B;
        min-width: 180px;
    }

    .add-btn {
        color: #5C7D27;
    }

    .form-box {
        box-shadow: 1px 2px 2px 2px #8080807a;
    }
</style>