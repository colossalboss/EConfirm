<template>
    <div class="w-full pb-8 px-3">
        <div class="top flex flex-col items-center">
            
            <div class="w-full main-form p-4 flex flex-column items-center md:w-6/12 mx-auto">
                <h1 class="bold text-xl form-title text-center">Line Manager’s Comment & Recommendation</h1>

                <div class="w-full">
                    <div class="w-full py-4">
                        <div class="w-12/12">
                            <div class="w-full">
                                <label for="" class="font-semibold">Performance Objective 1</label>
                                <textarea class="normal-input p-2 rounded w-full input"></textarea>
                            </div>
                        </div>
                        <div class="w-12/12">
                            <div class="w-full">
                                <label for="" class="font-semibold">Performance Objective 1</label>
                                <textarea class="normal-input p-2 rounded w-full input"></textarea>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="w-full">
                    <div class="w-full flex items-center">
                        <div class="w-1/12">
                            <input type="checkbox" class="normal-input p-4 rounded input" style="width: 25px;height:25px">
                        </div>
                        <div class="w-11/12">
                            <span>I hereby confirm that I have reviewed the employee’s performance and provided my assessment based on their performance and progress so far.</span>
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