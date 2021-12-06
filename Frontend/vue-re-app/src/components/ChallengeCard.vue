<template>
    <div class="card">
        <div class="feature">
            <h2 class="header">Paper Busket</h2>
            <p class="sub-header">In this week remeber to use paper bags only</p>
            
            <div class="image-box"></div>
            
        </div>
        <div class="progress-group">
            
        </div>
    </div>
</template>

<script>
export default {
    name: 'ChallengeCard'
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

.header {
    height: 30px;
    
    color: #000000;
}

.sub-header {
    height: 18px;
    
    color: #999999;
}
</style>