<template>
  <div class="card">
    <div class="feature">
      <h2 class="header">{{ quest.title }}</h2>
      <p class="sub-header">{{ quest.desc }}</p>

      <div class="image-box">
        <img src="../assets/Rectangle.svg" class="absolute-center" />
        <img src="../assets/PaperBag.png" class="absolute-center" />
      </div>
    </div>
    <div class="progress-group">
      <div class="progress-bar">
        <span
          v-for="i in quest.questLength"
          :key="i"
          :class="progressClass(i)"
          :style="progressStyles"
        ></span>
      </div>

      <div class="progress-info">
        <div>
          <h2 class="header">
            {{ quest.questLength - quest.questProgress }} days
          </h2>
          <p class="sub-header">to finish</p>
        </div>

        <div class="action-button">Add work</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "QuestCard",
  props: {
    quest: Object,
  },
  methods: {
    progressClass(i) {
      return {
        progress: true,
        checked: this.quest.questProgress >= i,
      };
    },
  },
  computed: {
    progressStyles() {
      return {
        width: `calc(100% / ${this.quest.questLength} - 1px)`,
      };
    },
  },
};
</script>

<style scoped>
.card {
  width: 340px;
  height: 510px;
  margin-bottom: 30px;

  background: #ffffff;
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

  height: 10px;
  float: left;

  background-color: #e8e8e8;
}
.progress.checked {
  background-color: #efe2c8;
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

@media screen and (min-width: 1000px) {
  .card {
    width: 250px;
    height: 410px;
    border-radius: 15px;
    box-shadow: 0px 4px 15px rgba(0, 0, 0, 0.1);
  }
  .card .feature,
  .card .progress-group {
    padding: 10px;
    width: 100%;
  }
  .card .feature {
    height: auto;
  }
  .card p {
    width: auto;
  }
  .card .image-box {
    width: 100%;
    height: 230px;
    margin-top: 0px;
  }

  .image-box img {
    width: 85%;
  }
  .image-box img:last-of-type {
    width: 65%;
  }
}
</style>
