<template>
    <div class="card">
        <div class="feature">
            <h2 class="header">{{ title }}</h2>
            <p class="sub-header">{{ desc }}</p>
            
            <div class="image-box">
                <img src="../assets/Rectangle.svg" class="absolute-center">
                <img src="../assets/PaperBag.png" class="absolute-center">
            </div>
            
        </div>
        <div class="progress-group">
            <div class="progress-bar">
                <span class="progress checked"></span><span class="progress checked"></span><span class="progress checked"></span><span class="progress checked"></span><span class="progress"></span><span class="progress"></span><span class="progress"></span>
            </div>
            
            <div class="progress-info">
                <div>
                    <h2 class="header">{{ questLength - questProgress }} days</h2>
                    <p class="sub-header">to finish</p>
                </div>
                
                <div class="action-button">Break</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'QuestCard',
    props: ['title', 'desc', 'questLength', 'questProgress']
}
</script>

<style scoped>
.card {
    width: 340px;
    height: 510px;
    
    background: #FFFFFF;
    box-shadow: 0px 4px 15px rgba(0, 0, 0, 0.25);
    border-radius: 27px;
}

.feature {
    width: 340px;
    height: 390px;
    
    padding: 16px 25px;
    background: linear-gradient(
        180deg, 
        rgba(255, 255, 255, 0) 0%, 
        rgba(242, 234, 205, 0.43) 100%
    );
}
.image-box {
    width: 270.5px;
    height: 259px;
    margin: 0 auto;
    margin-top: 40px;
    
    position: relative;
}

.header {
    height: 30px;
    
    color: #000000;
}
.sub-header {
    height: 18px;
    
    color: #999999;
}

.progress-group {
    padding: 15px 20px;
}

.progress-bar {
    height: 10px;
    margin: auto;
    
    border-radius: 5px;
    overflow: hidden;
}
.progress {
    display: block;
    width: calc(300px / 7 - 1px);
    height: 10px;
    float: left;
    
    background-color: #E8E8E8;
}
.progress.checked {
    background-color: #EFE2C8;
}
.progress:not(:last-child) {
    margin-right: 1px;
}

.progress-info {
    margin-top: 23px;
    display: flex;
    justify-content: space-between;
}

.action-button {
    width: 40%;
}

</style>